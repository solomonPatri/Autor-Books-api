using Microsoft.AspNetCore.Mvc;
using Autor_Books_Api.Autors.Dtos;
using Autor_Books_Api.Autors.Exceptions;
using Autor_Books_Api.Autors.Service;
using System.Security.AccessControl;
using Autor_Books_Api.Books.Dtos;
using Autor_Books_Api.Books.Exceptions;

namespace Autor_Books_Api.Autors
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class AutorController:ControllerBase
    {

        private readonly ICommandService _command;

        private readonly IQueryService _query;

        public AutorController(ICommandService command,IQueryService query)
        {
            this._command = command;
            this._query = query;

        }

        [HttpGet("allAutors")]

        public async Task<ActionResult<GetAllAutorDto>> GetAllAutorsAsync()
        {

            try
            {
                GetAllAutorDto response = await _query.GetAllAsync();

                return Ok(response);
            }catch(AutorNotFoundException nf)
            {
                return NotFound(nf.Message);
            }




        }


        [HttpPost("create")]

        public async Task<ActionResult<AutorResponse>> CreateAsync([FromBody] AutorRequest autor)
        {

            try
            {
                AutorResponse response = await this._command.CreateAutorAsync(autor);
                return Created("", response);


            }catch(AutorAlreadyException al)
            {
                return BadRequest(al.Message);
            }







        }


        [HttpPost("AddBook")]

        public async Task<ActionResult<BookResponse>> AddBookAsync([FromBody]BookRequest book)
        {

            try
            {

                var response = await _command.AddBookAsync(book);
                return Created("", response);

            }
            catch(AutorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }






        }

        [HttpPut("updateAutor/{id}")]

        public async  Task<ActionResult<AutorResponse>> UpdateAutorAsync([FromRoute]int id, [FromBody] AutorUpdateRequest update)
        {

            try
            {
                AutorResponse response = await _command.UpdateAutorAsync(id, update);

                return Accepted("", response);


            }
            catch(AutorNotFoundException nf)
            {
                return NotFound(nf.Message);

            }







        }


        [HttpDelete("DeleteAutor/{id}")]

        public async Task<ActionResult<AutorResponse>> DeleteAutorAsync([FromRoute]int id)
        {

            try
            {
                AutorResponse response = await _command.DeleteAutorAsync(id);

                return Accepted("", response);




            }catch(AutorNotFoundException nf)
            {
                return NotFound(nf.Message);

            }




        }


        [HttpDelete("DeleteBook/{autorid}/{bookid}")]

        public async Task<ActionResult<BookResponse>> DeleteBookAsync([FromRoute]int autorid, [FromRoute]int bookid)
        {

            try
            {
                BookResponse response = await _command.DeleteBookAsync(autorid, bookid);

                return Accepted("", response);


            }catch(BookNotFoundExceptions nb)
            {
                return NotFound(nb.Message);
            }
            catch(AutorNotFoundException nf)
            {
                return NotFound(nf.Message);
            }










        }




















    }
}
