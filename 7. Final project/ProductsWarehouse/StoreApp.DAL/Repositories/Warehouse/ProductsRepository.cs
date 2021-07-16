﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApp.DAL.EF;
using StoreApp.DAL.Entities.Warehouse;

namespace StoreApp.DAL.Repositories.Warehouse
{
    public class ProductsRepository : BaseRepository<Product>
    {
        public ProductsRepository(StoreContext context) : base(context)
        {
        }

        public override async Task Update(Product entity)
        {
            // get entity from DB
            var srchEntity = await Get(entity.Id);
            // change entity
            srchEntity.Name = entity.Name;
            srchEntity.Weight = entity.Weight;
            srchEntity.PrimeCost = entity.PrimeCost;
            srchEntity.Price = entity.Price;
            srchEntity.IsAvailable = entity.IsAvailable;
            srchEntity.ArrivalDate = entity.ArrivalDate;
            srchEntity.SellBy = entity.SellBy;
            srchEntity.AmountInStorage = entity.AmountInStorage;
            srchEntity.Rating = entity.Rating;
            srchEntity.PhotoPath = entity.PhotoPath;
            srchEntity.SelectionLabel = entity.SelectionLabel;
            srchEntity.CategoryId = entity.CategoryId;
            srchEntity.ProvisionerId = entity.ProvisionerId;

            if(srchEntity.ProvisionerId == 0)
            {
                // if user add new provisioner and immediately chose this provisioner while product adding or editing , provisionerId wil be 0, so take last added id from table of provisioners, in that case
                srchEntity.ProvisionerId = db.Provisioners
                    .ToList()
                    .OrderByDescending(p => p.Id)
                    .Take(1)
                    .First()
                    .Id; // provisioners can't be too many, so take last provisioner's id in this way
            }
            srchEntity.SectionId = entity.SectionId;
            // change entity state
            db.Entry(srchEntity).State = EntityState.Modified;
            // save changes
            await db.SaveChangesAsync();
        }

        public override async Task<List<Product>> GetAll(Func<Product, bool> predicate)
        {
            return await Task.Run(() => Table
            .Where(p => p.IsAvailable == true)
            .Where(predicate).ToList());
        }

        public async Task<Product> GetFullData(int id)
        {
            return await db.Set<Product>()
                .Include(p => p.Category)
                .Include(p => p.Provisioner)
                .Include(p => p.Section)
                .FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task UpdateProductRating(Product entity, int newValue)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Rating = newValue;
            db.Entry(srchEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public List<Product> GetAllSync()
        {
            return Table.ToList();
        }

        public async Task UpdateProductCount(Product entity, int newValue)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.AmountInStorage = newValue;
            db.Entry(srchEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task ChangeProductAvailability(Product entity, bool isProductAvailable)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.IsAvailable = isProductAvailable;
            db.Entry(srchEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
