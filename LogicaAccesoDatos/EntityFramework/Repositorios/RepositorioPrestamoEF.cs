using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.Entities;
using StellarMinds.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPrestamoEF : IRepositorioPrestamo
    {
        private StellarMindsContext _context;
        public RepositorioPrestamoEF(StellarMindsContext context)
        {
            _context = context;
        }


        public void Alta(Prestamo aAgregar)
        {
                aAgregar.Validar();
                _context.Prestamos.Add(aAgregar);
                _context.SaveChanges();
        }

        public void Devolver(int id)
        {
            Prestamo prestamo = FindById(id);
            if (prestamo.Estado == EstadoPrestamo.EN_PRESTAMO)
            {
                prestamo.Telescopio.CantDisp++;
                prestamo.Montura.CantDisp++;
                if (prestamo.Camara != null) { prestamo.Camara.CantDisp++; }
                if (prestamo.Ocular != null) { prestamo.Ocular.CantDisp++; }
                prestamo.Estado = EstadoPrestamo.DEVUELTO;
                _context.SaveChanges();
            }
        }
        public IEnumerable<Prestamo> FindAll()
        {
            return _context.Prestamos
                            .Include(p => p.Socio)
                            .Include(p => p.Telescopio)
                            .Include(p => p.Montura)
                            .Include(p => p.Camara)
                            .Include(p => p.Ocular)
                            .ToList();
        }

        public Prestamo FindById(int id)
        {
            return _context.Prestamos
                            .Where(p => p.Id == id)
                            .Include(p => p.Socio)
                            .Include(p => p.Telescopio)
                            .Include(p => p.Montura)
                            .Include(p => p.Camara)
                            .Include(p => p.Ocular)
                            .FirstOrDefault();
        }

        public IEnumerable<Prestamo> FindPrestamosSocio(int socioId)
        {
            return _context.Prestamos
                .Where(p =>
                    p.Socio.Id == socioId &&
                    p.Estado == EstadoPrestamo.EN_PRESTAMO)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .ToList();
        }

        public IEnumerable<Prestamo> FindPrestamosSocioEntreFechas(int socioId, int mes, int anio)
        {
            return _context.Prestamos
                .Where(p => p.SocioId == socioId && p.FechaInicio.Month == mes && p.FechaInicio.Year == anio)
                .Include(p => p.Telescopio)
                .Include(p => p.Montura)
                .Include(p => p.Camara)
                .Include(p => p.Ocular)
                .ToList();
        }

        

        public void Update(Prestamo aActualizar)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
