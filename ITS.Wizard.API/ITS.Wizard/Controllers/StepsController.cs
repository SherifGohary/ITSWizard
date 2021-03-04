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
    public class StepsController : ControllerBase
    {
        private readonly StepRepository stepRepository;
        private readonly UnitOfWork unitOfWork;
        public StepsController(StepRepository stepRepository, UnitOfWork unitOfWork)
        {
            this.stepRepository = stepRepository;
            this.unitOfWork = unitOfWork;
        }

        [Route("get/{id}")]
        [HttpGet]
        public Step Get(int id)
        {
            return stepRepository.Get(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IList<Step> GetAll()
        {
            return stepRepository.Get().Include(i=>i.Items).ToList();
        }

        [Route("add")]
        [HttpPost]
        public Step Add(Step model)
        {
            model.Name = Guid.NewGuid().ToString();
            model = stepRepository.Add(model);
            this.unitOfWork.Commit();
            return model;
        }

        [Route("update")]
        [HttpPost]
        public Step Update(Step model)
        {
            model = stepRepository.Update(model);
            this.unitOfWork.Commit();
            return model;
        }

        [Route("delete/{id}")]
        [HttpPost]
        public int Delete(int id)
        {
            id = stepRepository.Delete(id);
            this.unitOfWork.Commit();
            return id;
        }
    }
}
