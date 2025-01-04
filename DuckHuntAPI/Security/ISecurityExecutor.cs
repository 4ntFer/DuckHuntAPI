using DuckHuntAPI.Security.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace DuckHuntAPI.Security
{
    public abstract class ISecurityExecutor
    {

        protected HttpContext context { get; set; }
        protected NHibernate.ISession session { get; set; }
        protected string clientIPAddres { get; set; }

        public ISecurityExecutor(HttpContext context)
        {
            this.context = context;
            this.session = NHibernateHelper.GetSession(context);
            this.clientIPAddres = GetIPAddress();
        }

        public Boolean CanAccess() // CanAccess
        {
            Device device = GetCurrentClientDevice();

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

            if (CanResetAccesses())
                ResetAccesses();
            UpdateAccesses();
            if (CanBan())
                Ban();
            return false;
        }
        protected abstract string GetIPAddress();
        protected abstract void ResetAccesses();
        protected abstract bool CanResetAccesses();
        protected abstract void UpdateAccesses();
        protected abstract void Ban();
        protected abstract bool CanBan();
        protected abstract void Unban();
        protected abstract bool CanUnban();
        protected abstract void RegisterIp();
        protected abstract Device GetCurrentClientDevice();
    }
}
