using DuckHuntAPI.Security.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Linq;

namespace DuckHuntAPI.Security
{
    public class SecurityExecutor
    {
        protected HttpContext context { get; set; }
        protected NHibernate.ISession session { get; set; }

        public SecurityExecutor(HttpContext context) {
            this.context = context;
            this.session = NHibernateHelper.GetSession(context);
        }

        public Boolean IsBanned()
        {
            Device device = session.Query<Device>()
                .Where(d => d.ip == GetIPAddress())
                .FirstOrDefault();

            if (device == null) // device não está retistrado
            {
                RegisterIp();
            }
            else
            { // device está registrado
                if (device.banned == 1)
                {
                    if (CanUnban())
                    {
                        Unban();
                        RegisterIp();
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            RegisterAccess();
            if (CanBan())
                Ban();
            return false;
        }

        protected string GetIPAddress()
        {
            string ipAddress = context.Connection.RemoteIpAddress.ToString();

            return ipAddress;
        }

        private void Ban()
        {
            ITransaction tx = session.BeginTransaction();

            try
            {
                Device device = session.Query<Device>()
                    .Where(d => d.ip == GetIPAddress())
                    .FirstOrDefault();
                
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
                deviceBan.endTime = (DateTime.Now).AddDays(7);

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

        private bool CanBan()
        {
            Device d = session.Query<Device>().
                Where(d => d.ip == GetIPAddress())
                .FirstOrDefault();
            if (d.accesses >= 1000)
            {
                return true;
            }

            return false;
        }

        private void Unban()
        {
            ITransaction tx = session.BeginTransaction();

            try
            {
                Device device = session.Query<Device>()
                    .Where(d => d.ip == GetIPAddress())
                    .FirstOrDefault();

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

        private bool CanUnban()
        {

            Device device = null;
            Ban deviceBan = null;

            Ban result = session.QueryOver<Ban>(() => deviceBan)
                .JoinEntityAlias(
                    () => device,
                    () => deviceBan.deviceId == device.id,
                    JoinType.InnerJoin
                )
                .Where(() => device.ip == GetIPAddress())
                .SingleOrDefault();

            if (result.endTime.CompareTo(DateTime.Now) <= 0)
                return true;

            return false;
        }

        private void RegisterAccess()
        {
            ITransaction tx = session.BeginTransaction();

            try
            {
                Device d = session.Query<Device>()
                    .Where(d => d.ip == GetIPAddress())
                    .FirstOrDefault();

                DateTime timeResetAccessRange = d.firstAccess.AddDays(1);

                if (timeResetAccessRange.CompareTo(DateTime.Now) <= 0)
                {
                    d.firstAccess = DateTime.Now;
                    d.accesses = 0;
                }

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

        private void RegisterIp()
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

                d.ip = GetIPAddress();
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
