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
        public async Task<Account> TakeValueAwayByAccountNumber(int accountNumber, int takeAwaiValue)
        {           
            var Account = _appDbContext.Account
                .Include(e => e.User)
                .Where(e => e.AccountNumber == accountNumber)
                .FirstOrDefault();
            

            if (takeAwaiValue < 0)  throw new Exception("Valor inválido!"); 
            if (Account == null)   throw new Exception("Conta não encontrada!"); 

            if (takeAwaiValue <= Account.AccountValue)
            {
                Account.AccountValue -= takeAwaiValue;
                _appDbContext.Update(Account);
                await _appDbContext.SaveChangesAsync();

                return Account;
            }
            else
            {
                throw new Exception("Saldo insuficiente!");
            }           
        }

        // depositar
        public async Task<Account> DepositValueByAccountNumber(int accountNumber, int addValue)
        {                       
            var Account = _appDbContext.Account
                .Include(e => e.User)
                .Where(e => e.AccountNumber == accountNumber)
                .FirstOrDefault();

            if (addValue < 0) throw new Exception("Valor inválido!");
            if (Account == null) throw new Exception("Conta não encontrada!");

            Account.AccountValue += addValue;
            _appDbContext.Update(Account);
            await _appDbContext.SaveChangesAsync();

            return Account;            
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

            throw new Exception("Conta não encontrada!");
        }

        public List<Account> GetAllAccounts()
        {
            var Account = _appDbContext.Account.ToList();

            if (Account != null)
            {
                return Account;
            }

            throw new Exception("Nenhuma conta encontrada!");
        }
    }
}
