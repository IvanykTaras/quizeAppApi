﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using quizeAppApi.Models;
using quizeAppApi.Services.Interface;

namespace quizeAppApi.Services
{
    public class CategoryService: IService<Category>
    {
        
        //Category collection
        private readonly IMongoCollection<Category> _categoryCollection;


        public CategoryService(IOptions<QuizeDatabaseSettings> option) {
            
            var mongoClient = 
                new MongoClient(option.Value.ConnectionString);

            var mongoDatabase = 
                mongoClient.GetDatabase(option.Value.DatabaseName);

            _categoryCollection =
                mongoDatabase.GetCollection<Category>(option.Value.CategoryCollectionName);


        }

        //================
        //Category methods
        //================

        public async Task<List<Category>> GetAsync()
            => await _categoryCollection.Find(_ => true).ToListAsync();
       
        public async Task<Category?> GetAsync(string id)
            => await _categoryCollection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Category item) 
            => await _categoryCollection.InsertOneAsync(item);


        public async Task UpdateAsync(string id, Category item)
            => await _categoryCollection.ReplaceOneAsync(e => e.Id == id, item);
        public async Task RemoveAsync(string id)
            => await _categoryCollection.DeleteOneAsync(id);
    }
}
