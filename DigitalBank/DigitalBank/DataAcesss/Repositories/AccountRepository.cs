using DigitalBank.DataAcesss.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DigitalBank.DataAcesss.Repositories
{
    public class AccountRepository
    {
        private readonly AppDbContext _appDbContext;

        public AccountRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        // sacar
        public Account TakeValueAwayByAccountNumber(int accountNumber, int takeAwaiValue)
        {
            var Account = _appDbContext.Account
                .Include(e => e.User)
                .Where(e => e.AccountNumber == accountNumber)
                .FirstOrDefault();

            if (Account != null) {
                return Account;
            }

            return null;
        }

        // depositar
        public Account DepositValueByAccountNumber(int accountNumber, int takeAwaiValue)
        {
            var Account = _appDbContext.Account
                .Include(e => e.User)
                .Where(e => e.AccountNumber == accountNumber)
                .FirstOrDefault();

            if (Account != null)
            {
                return Account;
            }

            return null;
        }

        // saldo
        public Account GetAccountDataByAccountNumber(int accountNumber)
        {
            var Account = _appDbContext.Account
                .Include(e => e.User)
                .Where(e => e.AccountNumber == accountNumber)
                .FirstOrDefault();

            if (Account != null)
            {
                return Account;
            }

            return null;
        }

    }
}
