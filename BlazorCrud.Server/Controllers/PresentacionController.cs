using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BlazorCrud.Server.Models;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionController : ControllerBase
    {
        private readonly GalloGiroContext _dbcontext;

        public PresentacionController(GalloGiroContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<PresentacionDTO>>();
            var listaPresentacionDTO = new List<PresentacionDTO>();

            try
            {

                foreach (var item in await _dbcontext.Presentacions.ToListAsync())
                {
                    listaPresentacionDTO.Add(new PresentacionDTO
                    {
                        PresentacionId = item.PresentacionId,
                        NombrePresent = item.NombrePresent,
                        DescripcionPresent = item.DescripcionPresent,
                        
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaPresentacionDTO;

            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<PresentacionDTO>();
            var PresentacionDTO = new PresentacionDTO();

            try
            {

                var dbPresentacion = await _dbcontext.Presentacions.FirstOrDefaultAsync(x=>x.PresentacionId== id);

                if(dbPresentacion != null)
                {
                    PresentacionDTO.PresentacionId = dbPresentacion.PresentacionId;
                    PresentacionDTO.NombrePresent = dbPresentacion.NombrePresent;
                    PresentacionDTO.DescripcionPresent = dbPresentacion.DescripcionPresent;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = PresentacionDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }

            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(PresentacionDTO presentacion)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbPresentacion = new Presentacion
                {
                    PresentacionId = presentacion.PresentacionId,
                    NombrePresent = presentacion.NombrePresent,
                    DescripcionPresent = presentacion.DescripcionPresent,

                };

                _dbcontext.Presentacions.Add(dbPresentacion);
                await _dbcontext.SaveChangesAsync();

                if(dbPresentacion.PresentacionId != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbPresentacion.PresentacionId;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No Guardado";
                }


            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(PresentacionDTO presentacion,int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbPresentacion = await _dbcontext.Presentacions.FirstOrDefaultAsync(e=>e.PresentacionId==id);

                

                if (dbPresentacion != null)
                {

                    dbPresentacion.PresentacionId = presentacion.PresentacionId;
                    dbPresentacion.NombrePresent = presentacion.NombrePresent;
                    dbPresentacion.DescripcionPresent = presentacion.DescripcionPresent;


                    _dbcontext.Presentacions.Update(dbPresentacion);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbPresentacion.PresentacionId;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No Encontrado";
                }


            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbPresentacion = await _dbcontext.Presentacions.FirstOrDefaultAsync(e => e.PresentacionId == id);



                if (dbPresentacion != null)
                {

                    


                    _dbcontext.Presentacions.Remove(dbPresentacion);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No Encontrado";
                }


            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

        }

    }
}
