using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeApp.DAL.Repositories;

namespace PracticeApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        OrdersRepository OrdersRepository { get; }
        UsersRepository UsersRepository { get; }
    }
}
