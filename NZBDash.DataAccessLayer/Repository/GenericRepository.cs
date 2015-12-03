﻿#region Copyright
//  ***********************************************************************
//  Copyright (c) 2015 Jamie Rees
//  File: GenericRepository.cs
//  Created By: Jamie Rees
// 
//  Permission is hereby granted, free of charge, to any person obtaining
//  a copy of this software and associated documentation files (the
//  "Software"), to deal in the Software without restriction, including
//  without limitation the rights to use, copy, modify, merge, publish,
//  distribute, sublicense, and/or sell copies of the Software, and to
//  permit persons to whom the Software is furnished to do so, subject to
//  the following conditions:
// 
//  The above copyright notice and this permission notice shall be
//  included in all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//  EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//  MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//  NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
//  LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//  OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//  WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//  ***********************************************************************
#endregion
using System.Collections.Generic;

using Dapper.Contrib.Extensions;

using NZBDash.Common.Interfaces;
using NZBDash.Common.Models.Data;
using NZBDash.DataAccessLayer.Interfaces;

namespace NZBDash.DataAccessLayer.Repository
{
    public class GenericRepository<T> : ISqlRepository<T> where T : Entity
    {
        private ISqliteConfiguration Config { get; set; }
        private ILogger Logger { get; set; }

        public GenericRepository(ILogger logger, ISqliteConfiguration config)
        {
            Config = config;
            Logger = logger;
            Logger.Trace(string.Format("Started GenericRepository<{0}>", typeof(T)));
        }

        public long Insert(T entity)
        {
            using (var cnn = Config.DbConnection())
            {
                cnn.Open();
                return cnn.Insert(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var db = Config.DbConnection())
            {
                db.Open();
                var result = db.GetAll<T>();
                return result;
            }
        }

        public T Get(long id)
        {
            using (var db = Config.DbConnection())
            {
                db.Open();
                var result = db.Get<T>(id);
                return result;
            }
        }

        public void Delete(T entity)
        {
            using (var db = Config.DbConnection())
            {
                db.Open();
                db.Delete(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var db = Config.DbConnection())
            {
                db.Open();
                return db.Update(entity);
            }
        }
    }
}