using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.OtpService;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services
{
    public class OtpService : IOtpService
    {

        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;

        private const string ApiKey = "564557384C4C4C743555524D49356E2F314F376938594C47784B586A393735346938704A663164324266733D";
        private const string Sender = "2000660110";

        public OtpService(HttpClient httpClient, ApplicationDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task SendOtpAsync(string phoneNumber)
        {
            var otpCode = new Random().Next(100000,999999).ToString();

            var otp = new Otp
            {
                PhoneNumber = phoneNumber,
                Code = otpCode,
                ExpirationTime = DateTime.UtcNow.AddMinutes(2)
            };
            _context.Otps.Add(otp);
            await _context.SaveChangesAsync();
            var apiKey = "564557384C4C4C743555524D49356E2F314F376938594C47784B586A393735346938704A663164324266733D";
            var url = $"https://api.kavenegar.com/v1/{apiKey}/verify/lookup.json?receptor={phoneNumber}&token={otpCode}&template=login";


            using var client = new HttpClient();
            await client.GetAsync(url);
        }

        public async Task<bool> VerifyOtpAsync(string phoneNumber,string otpCode)
        {
            var now = DateTime.UtcNow;
            var otp= await _context.Otps
                .Where(x=>x.PhoneNumber ==phoneNumber&& x.Code == otpCode&&x.ExpirationTime>now)
                .OrderByDescending(x=>x.ExpirationTime)
                .FirstOrDefaultAsync();

            return otp != null;

        }
    }
}
