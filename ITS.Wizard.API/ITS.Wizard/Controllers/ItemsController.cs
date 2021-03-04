using ITS.Wizard.Entities;
using ITS.Wizard.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Wizard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository itemRepository;
        private readonly UnitOfWork unitOfWork;
        public ItemsController(ItemRepository itemRepository, UnitOfWork unitOfWork)
        {
            this.itemRepository = itemRepository;
            this.unitOfWork = unitOfWork;
        }

        [Route("get/{id}")]
        [HttpGet]
        public Item Get(int id)
        {
            return itemRepository.Get(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IList<Item> GetAll()
        {
            return itemRepository.Get().ToList();
        }

        [Route("get-step-items/{id}")]
        [HttpGet]
        public IList<Item> GetStepItems(int id)
        {
            var result = itemRepository.Get(item => item.StepId == id).ToList();
            return result;
        }

        [Route("add")]
        [HttpPost]
        public Item Add(Item model)
        {
            model = itemRepository.Add(model);
            this.unitOfWork.Commit();
            return model;
        }

        [Route("update")]
        [HttpPost]
        public Item Update(Item model)
        {
            model = itemRepository.Update(model);
            this.unitOfWork.Commit();
            return model;
        }

        [Route("delete/{id}")]
        [HttpPost]
        public int Delete(int id)
        {
            id = itemRepository.Delete(id);
            this.unitOfWork.Commit();
            return id;
        }
    }
}
