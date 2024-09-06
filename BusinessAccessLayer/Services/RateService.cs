using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class RateService
    {
        private readonly MovieDBContext _context;

        public RateService(MovieDBContext context)
        {
            _context = context;
        }
        public bool Update(int idUser, int idRate, Rate rate)
        {
            RateRepository _repository = new RateRepository(_context);
            if (_repository.GetById(idRate).IdUser == idUser)
            {
                try
                {
                    _repository.Update(rate, idRate);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Create(int idUser, int idMovie, int evaluation)
        {
            RateRepository _repository = new RateRepository(_context);
            try
            {
                _repository.Create(new Rate { Evaluation = evaluation, IdMovie = idMovie, IdUser = idUser });
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(int idUser, int idRate)
        {
            RateRepository _repository = new RateRepository(_context);
            var rate = _repository.GetById(idRate);
            if (rate != null && rate.IdUser == idUser)
            {
                try
                {
                    _repository.Delete(rate);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
