using DuckHuntAPI.Security.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Linq;

namespace DuckHuntAPI.Security
{
    public class SecurityExecutor : ISecurityExecutor
    {
        public int clientAllowedAccesses { get; set; }
        public int clientAllowedAccessesRange { get; set; }
        public int banTime { get; set; }
        protected string clientIPAddres { get; set; }

        public SecurityExecutor(
            HttpContext context, 
            int clientAllowedAccesses,
            int clientAllowedAccessesRange,
            int banTime) : base(context)
        {
            this.clientAllowedAccesses = clientAllowedAccesses;
            this.banTime = banTime;
            this.clientAllowedAccessesRange = clientAllowedAccessesRange;
            this.clientIPAddres = GetIPAddress();
        }

        private string GetIPAddress()
        {
            string ipAddress = context.Connection.RemoteIpAddress.ToString();

            return ipAddress;
        }

        protected override Device GetCurrentClientDevice() {
            return session.Query<Device>()
                .Where(d => d.ip == clientIPAddres)
                .FirstOrDefault();
        }

        protected override void Ban()
        {
            ITransaction tx = session.BeginTransaction();

            try
            {
                Device device = GetCurrentClientDevice();
                
                Ban deviceBan = new Ban();

                if (session.Query<Ban>().IsNullOrEmpty())
                {
                    deviceBan.id = 0;
                }
                else
                {
                    deviceBan.id = session.Query<Ban>()
                        .Max(d => d.id) + 1;
                }

                deviceBan.deviceId = device.id;
                deviceBan.startTime = DateTime.Now;
                deviceBan.endTime = (DateTime.Now).AddDays(banTime);

                device.banned = 1;

                session.Update(device);
                session.SaveOrUpdate(deviceBan);
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
                throw e;
            }
            finally
            {
                tx.Dispose();
            }
        }

        protected override bool CanBan()
        {
            Device d = GetCurrentClientDevice();

            if (d.accesses >= clientAllowedAccesses)
            {
                return true;
            }

            return false;
        }

        protected override void Unban()
        {
            ITransaction tx = session.BeginTransaction();

            try
            {
                Device device = GetCurrentClientDevice();

                Ban deviceBan = session.Query<Ban>()
                    .Where(db => db.deviceId == device.id)
                    .FirstOrDefault();

                session.Delete(deviceBan);
                session.Delete(device);
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
                throw e;
            }
            finally
            {
                tx.Dispose();
            }
        }

        protected override bool CanUnban()
        {

            Device device = null;
            Ban deviceBan = null;

            Ban result = session.QueryOver<Ban>(() => deviceBan)
                .JoinEntityAlias(
                    () => device,
                    () => deviceBan.deviceId == device.id,
                    JoinType.InnerJoin
                )
                .Where(() => device.ip == clientIPAddres)
                .SingleOrDefault();

            if (result.endTime.CompareTo(DateTime.Now) <= 0)
                return true;

            return false;
        }

        protected override Boolean CanResetAccesses() {
            Device d = GetCurrentClientDevice();

            DateTime timeResetAccessRange = d.firstAccess.AddDays(clientAllowedAccessesRange);

            if (timeResetAccessRange.CompareTo(DateTime.Now) <= 0)
            {
                return true;
            }

            return false;
        }

        protected override void ResetAccesses()
        {
            ITransaction tx = session.BeginTransaction();

            try
            {
                Device d = GetCurrentClientDevice();

                d.firstAccess = DateTime.Now;
                d.accesses = 0;

                session.Update(d);
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
                throw e;
            }
            finally
            {
                tx.Dispose();
            }
        }

        protected override void UpdateAccesses()
        {
            ITransaction tx = session.BeginTransaction();

            try
            {
                Device d = GetCurrentClientDevice();

                d.accesses++;
                session.Update(d);
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
                throw e;
            }
            finally
            {
                tx.Dispose();
            }
        }

        protected override void RegisterIp()
        {
            ITransaction tx = session.BeginTransaction();

            try
            {
                Device d = new Device();

                if (session.Query<Device>().IsNullOrEmpty()) {
                    d.id = 0;
                }
                else{
                    d.id = session.Query<Device>()
                        .Max(d => d.id) + 1;
                }

                d.ip = clientIPAddres;
                d.banned = 0;
                d.firstAccess = DateTime.Now;
                session.SaveOrUpdate(d);
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
                throw e;
            }
            finally
            {
                tx.Dispose();
            }
        }
    }
}
