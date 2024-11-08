using Domain.Interface;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generic
{
    public class RepositoryGeneric<T> : InterfaceGeneric<T>, IDisposable where T : class
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryGeneric()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }


        public void Adcionar(T Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<T>().Add(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public void Atualizar(T Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<T>().Update(Objeto);
                banco.SaveChangesAsync();
            }
        }



        public void Excluir(T Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<T>().Remove(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public IList<T> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return banco.Set<T>().AsNoTracking().ToList();
            }
        }

        public T ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return banco.Set<T>().Find(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
