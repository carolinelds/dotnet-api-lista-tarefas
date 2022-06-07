using Microsoft.EntityFrameworkCore;
using ListaTarefas.DAL;
using ListaTarefas.Domain.DTO;
using ListaTarefas.Services;
using System;
using Xunit;


namespace ListaTarefas.Tests.Services
{
    public partial class TarefasServiceTest : IDisposable
    {
        private readonly AppDbContext _dbContext;
        private readonly TarefasService _service;

        public TarefasServiceTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _dbContext = new AppDbContext(options);
            _service = new TarefasService(_dbContext);
        }


        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
