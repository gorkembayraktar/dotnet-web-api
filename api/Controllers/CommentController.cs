using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepository)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comments = await _commentRepo.GetAllAsync();
            var commentsdto = comments.Select(c => c.ToCommentDto());

            return Ok(commentsdto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment is null) return NotFound();

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentdto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _stockRepo.StockExists(stockId))
            {
                return BadRequest("Stock bulunamadı.");
            }
            var commentModel = commentdto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.UpdateAsync(id, dto.ToCommentFromUpdate());

            if (comment is null) return NotFound("Comment bulunamadı");

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var commentModel = await _commentRepo.DeleteAsync(id);
            if (commentModel is null) return NotFound("comment bulunamadı");

            return Ok(commentModel);
        }
    }
}