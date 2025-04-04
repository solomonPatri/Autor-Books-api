using AutoMapper;
using Autor_Books_Api.Autors.Dtos;
using Autor_Books_Api.Autors.Model;
using Autor_Books_Api.Data;
using System.Data.Entity;
using Autor_Books_Api.Autors.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Autor_Books_Api.Books.Dtos;
using Autor_Books_Api.Books.Model;

namespace Autor_Books_Api.Autors.Repository
{
    public class AutorRepo:IAutorRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AutorRepo(AppDbContext conetxt,IMapper mapper)
        {
            this._context = conetxt;
            this._mapper = mapper;


        }

        public async Task<GetAllAutorDto> GetAllAsync()
        {
            var autors = await _context.Autors.Include(s => s.Books)
                .ToListAsync();

            var mapped = _mapper.Map<List<AutorResponse>>(autors);

            return new GetAllAutorDto
            {
                ListAutor = mapped
            };



        }

        public async Task<AutorResponse> CreateAutorAsync(AutorRequest request)
        {

            var autorEntity = _mapper.Map<Autor>(request);

            await _context.Autors.AddAsync(autorEntity);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<AutorResponse>(autorEntity);

            return response;


        }

       public async  Task<AutorResponse> GetByIdAsyn(int id)
        {

            var autors = await _context.Autors
                .Include(s => s.Books)
                .FirstOrDefaultAsync(s => s.Id == id);

            return _mapper.Map<AutorResponse>(autors);

            
        }

        public async Task<Autor?> GetEntityByIdAsync(int id)
        {
            return await _context.Autors.Include(s => s.Books)
                .FirstOrDefaultAsync(s => s.Id == id);


        }

        public async Task<AutorResponse> UpdateAsync(int id, AutorUpdateRequest update)
        {
            Autor exist = await _context.Autors.FindAsync(id);

            if (update.Name != null)
            {
                exist.Name = update.Name;

            }
            if (update.Email != null)
            {
                exist.Email = update.Email;


            }
            if (update.Age.HasValue)
            {
                exist.Age = update.Age.Value;
            }

            _context.Autors.Update(exist);
            await _context.SaveChangesAsync();

            AutorResponse response = _mapper.Map<AutorResponse>(exist);

            return response;





        }



       public async Task UpdateAsync(Autor autor)
        {

            _context.Autors.Update(autor);

            await _context.SaveChangesAsync();



        }


        public async Task<AutorResponse> FindByNameAutorAsync(string name)
        {
            Autor autor = await _context.Autors.FirstOrDefaultAsync(n => n.Name.Equals(name));

            AutorResponse response = _mapper.Map<AutorResponse>(autor);

            return response;

        }


        public async Task<AutorResponse>DeleteAutorAsync(int id)
        {

            Autor autor = await _context.Autors.FindAsync(id);

            AutorResponse response = _mapper.Map<AutorResponse>(autor);

            _context.Remove(autor);

            await _context.SaveChangesAsync();

            return response;









        }


        public async Task<BookResponse> DeleteBookAsync(int idautor,int idbook)
        {

            Autor autor = await GetEntityByIdAsync(idautor);

            Book book = autor.Books.FirstOrDefault(s => s.Id == idbook);

            if (book != null)
            {
                autor.Books.Remove(book);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<BookResponse>(book);






        }


        public async Task<AutorResponse> FindByIdAsync(int id)
        {
            Autor autor = await _context.Autors.FindAsync(id);

            AutorResponse response = _mapper.Map<AutorResponse>(autor);

            return response;


        }















    }
}
