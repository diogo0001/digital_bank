using DigitalBank.DataAcesss.Entities;
using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var Account = _appDbContext.Account
                    .Include(e => e.User)
                    .Where(e => e.AccountNumber == accountNumber)
                    .FirstOrDefault();

                if (takeAwaiValue < 0) throw new CustomExeption("Valor inválido!");
                if (Account == null) throw new CustomExeption("Conta não encontrada!");


                if (takeAwaiValue <= Account.AccountValue)
                {
                    Account.AccountValue -= takeAwaiValue;
                    _appDbContext.Update(Account);
                    _appDbContext.SaveChangesAsync();

                    return Account;
                }
                else
                {
                    throw new CustomExeption("Saldo insuficiente!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Problema ao realizar a transação!", e);
            }
        }

        // depositar
        public Account DepositValueByAccountNumber(int accountNumber, int addValue)
        {
            try { 
                var Account = _appDbContext.Account
                    .Include(e => e.User)
                    .Where(e => e.AccountNumber == accountNumber)
                    .FirstOrDefault();
            
                if(addValue < 0) throw new CustomExeption("Valor inválido!");
                if (Account == null) throw new CustomExeption("Conta não encontrada!");

                Account.AccountValue += addValue;
                _appDbContext.Update(Account);
                _appDbContext.SaveChangesAsync();

                return Account;
            }
            catch (Exception e)
            {
                throw new Exception("Problema ao realizar a transação!", e);
            }
        }

        // saldo
        public Account GetAccountDataByAccountNumber(int accountNumber)
        {
            try { 
                var Account = _appDbContext.Account
                    .Include(e => e.User)
                    .Where(e => e.AccountNumber == accountNumber)
                    .FirstOrDefault();

                if (Account != null)
                {                
                    return Account;
                }

                throw new CustomExeption("Conta não encontrada!");
            }
            catch (Exception e)
            {
                throw new Exception("Problema ao realizar a transação!", e);
            }
        }

        public List<Account> GetAllAccounts()
        {
            var Account = _appDbContext.Account.ToList();

            if (Account != null)
            {
                return Account;
            }

            throw new CustomExeption("Nenhuma conta encontrada!");
        }

        private class CustomExeption : Exception
        {
            public CustomExeption(string message) : base(message){}
        }
    }
}
