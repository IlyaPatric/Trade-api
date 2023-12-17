using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeApi.Dto;
using TradeApi.Tables;

namespace TradeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        private Manufacturer? Manufacturer;
        private Provider? Provider;
        private Category? Category;

        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _context.product
                .Include(e => e.manufacturer)
                .Include(e => e.provider)
                .Include(e => e.category)
                .ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        [HttpGet("{article}")]
        public async Task<ActionResult<ProductDto>> GetProduct(string article)
        {
            var product = await _context.product
                .Include(p => p.manufacturer)
                .Include(p => p.provider)
                .Include(p => p.category)
                .FirstOrDefaultAsync(p => p.article == article);

            if (product == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProductDto>(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto productDto)
        {
            await GetForeignKey(productDto);
            if (Manufacturer == default ||
                Provider == default ||
                Category == default)
            {
                return BadRequest();
            }

            var product = new Product()
            {
                article = productDto.article,
                name = productDto.name,
                max_discount_amount = productDto.max_discount_amount,
                manufacturerId = Manufacturer.id,
                providerId = Provider.id,
                categoryId = Category.id,
                price = productDto.price,
                discount_amount = productDto.discount_amount,
                quantity_in_stock = productDto.quantity_in_stock,
                description = productDto.description,
                photo = productDto.photo
            };

            _context.product.Add(product);
            
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { article = productDto.article }, productDto);
        }

        [HttpPut("{article}")]
        public async Task<IActionResult> PutProduct(string article, ProductDto productDto)
        {
            if (article != productDto.article)
            {
                return BadRequest();
            }

            await GetForeignKey(productDto);
            if (Manufacturer == default ||
                Provider == default ||
                Category == default)
            {
                return BadRequest();
            }

            var product = new Product()
            {
                article = productDto.article,
                name = productDto.name,
                max_discount_amount = productDto.max_discount_amount,
                manufacturerId = Manufacturer.id,
                providerId = Provider.id,
                categoryId = Category.id,
                price = productDto.price,
                discount_amount = productDto.discount_amount,
                quantity_in_stock = productDto.quantity_in_stock,
                description = productDto.description,
                photo = productDto.photo
            };

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            } 
            catch (DbUpdateConcurrencyException) 
            {
                if (!ProductExist(article))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string article)
        {
            var product = await _context.product.FindAsync(article);
            
            if (product == null)
            {
                return NotFound();
            }

            _context.product.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private async Task GetForeignKey(ProductDto productDto)
        {
            Manufacturer = await _context.manufacturer.FirstOrDefaultAsync(o =>
                o.name == productDto.manufacturer
            );
            Provider = await _context.provider.FirstOrDefaultAsync(o =>
                o.name == productDto.provider
            );
            Category = await _context.category.FirstOrDefaultAsync(o =>
                o.name == productDto.category
            );
        }

        private bool ProductExist(string article)
        {
            return _context.product.Any(e => e.article == article);
        }
    }
}
