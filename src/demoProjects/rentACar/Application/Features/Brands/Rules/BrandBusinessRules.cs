﻿using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules : BaseBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result=await _brandRepository.GetListAsync(b=>b.Name==name);
            // yazıyı constant a çevirmekte fayda var
            if (result.Items.Any()) throw new BusinessException("Brand Name already exists");
        }

        public void BrandShouldExistWhenRequested(Brand brand)
        {
            if(brand==null) throw new BusinessException("Requested brand does not exist");
        }
    }
}
