using SocNetw.Core.Models;
using SocNetw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SocNetw.DAL.Repositories
{
    public interface IAccountRepository
    {
        bool ContainsLogin(string login);

        void CreateNewAccount(Credentials credentials, Account account);

        IEnumerable<Account> FindAll(Func<Account, bool> searchFunction);
        
        Account FindAccount(Func<Account, bool> searchFunction);

        void DeleteAccount(Account account);

        void EditAccount(Account account, Action<Account> editAction);

    }
    public class AccountRepository : IAccountRepository
    {
        SocNetwContext _ctx;

        public AccountRepository(SocNetwContext ctx)
        {
            _ctx = ctx;
        }

        public bool ContainsLogin(string login)
        {
            return _ctx.CredentialsEntities.Any(x => x.Login == login);
        }

        public void DeleteAccount(Account account)
        {
            var acc = _ctx.AccountEntities.FirstOrDefault(x => x.UniqueID == account.UniqueID);
            if(acc != null)
                _ctx.AccountEntities.Remove(acc);
            _ctx.SaveChanges();
        }

        public void EditAccount(Account account, Action<Account> editAction)
        {
            var acc = _ctx.AccountEntities.FirstOrDefault(x => x.UniqueID == account.UniqueID);
            if (acc != null)
            {
                editAction(acc);
            }
            _ctx.SaveChanges();
        }

        public IEnumerable<Account> FindAll(Func<Account, bool> searchFunction)
        {
            return _ctx.AccountEntities.Where(x => searchFunction(x));
        }

        public Account FindAccount(Func<Account, bool> searchFunction)
        {
            return FindAll(searchFunction).FirstOrDefault();
        }

        public void CreateNewAccount(Credentials credentials, Account account)
        {
            var accountEntity = AccountEntity.MapFromModel(account);
            var credentialsEntity = CredentialsEntity.MapFromModel(credentials);

            _ctx.AccountEntities.Add(accountEntity);

            credentialsEntity.AccountEntity = accountEntity;

            _ctx.CredentialsEntities.Add(credentialsEntity);
            _ctx.SaveChanges();
        }
    }
}
