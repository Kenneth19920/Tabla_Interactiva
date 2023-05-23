using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G5_caso1.Models;

namespace G5_caso1.Class
{
    public class Persona
    {

        public IEnumerable<EMPLEADO> consultar()
        {
            try
            {
                using (G5_CASO1Entities db = new G5_CASO1Entities())
                {
               
                    return db.EMPLEADO.ToList();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("No se pudo conectar a la base de datos.", ex);
            }
        }


        public void guardar(EMPLEADO empleado)
        {

            try
            {

                if (empleado == null)
                {

                    throw new ArgumentNullException("El parámetro 'Empleado' no puede ser nulo.");

                }

                using (var db = new G5_CASO1Entities())
                {

                    db.EMPLEADO.Add(empleado);
                    db.SaveChanges();

                }

            }
            catch (ArgumentNullException ex)
            {

                Console.WriteLine(ex.Message);

            }

        }


        public EMPLEADO ConsultarId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El parámetro 'id' debe ser un entero positivo.");
            }

            EMPLEADO empleadoEncontrado;

            using (var db = new G5_CASO1Entities())
            {
                empleadoEncontrado = db.EMPLEADO.FirstOrDefault(a => a.ID_EMPLEADO == id);
            }

            return empleadoEncontrado;
        }


        public void eliminar(EMPLEADO modelo)
        {
            if (modelo == null || modelo.ID_EMPLEADO < 0)
            {
                throw new ArgumentException("El modelo de alumno no es válido.");
            }

            using (G5_CASO1Entities db = new G5_CASO1Entities())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void modificar(EMPLEADO modelo)
        {
            if (modelo == null)
            {
                throw new ArgumentNullException("El parámetro 'modelo' no puede ser nulo.");
            }

            using (G5_CASO1Entities db = new G5_CASO1Entities())
            {
                var alumnoExistente = db.EMPLEADO.FirstOrDefault(a => a.ID_EMPLEADO == modelo.ID_EMPLEADO);

                if (alumnoExistente == null)
                {
                    throw new ArgumentException($"No se encontró ningún alumno con el carnet '{modelo.ID_EMPLEADO}'.");
                }

                db.Entry(alumnoExistente).CurrentValues.SetValues(modelo);
                db.SaveChanges();
            }
        }



    }
}