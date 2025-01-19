using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    using System.Linq;
    using System.Threading.Tasks;
    using BCrypt.Net;
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;

    public class PasswordMigration
    {
        private readonly ApplicationDbContext _context;

        public PasswordMigration(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task MigrateProfessorPasswordsAsync()
        {
            // Obtener todos los profesores con contraseñas sin hashear
            var professors = await _context.Professor
                .Where(p => !p.Password.StartsWith("$2a$")) // Filtra las contraseñas no hashadas
                .ToListAsync();

            foreach (var professor in professors)
            {
                // Generar hash de la contraseña
                professor.Password = BCrypt.HashPassword(professor.Password);
            }

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
            Console.WriteLine($"Contraseñas migradas: {professors.Count}");
        }
    }

}
