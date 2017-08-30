using System;

namespace Core.Domain.Auth
{
    public class RefreshToken : BaseEntity
    {
        public string Subject { get; set; }

        public Guid TokenValue { get; set; }

        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }

        public string ProtectedTicket { get; set; }
    }
}
