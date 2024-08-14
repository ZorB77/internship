﻿using ETMovies.DatabaseContext;
using ETMovies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Service
{
    public class StudioService
    {
        public MyDbContext Context;
        public StudioService(MyDbContext context) 
        {
            Context = context;
        }

        #region StudioCRUD

        public void AddStudio(Studio studio)
        {

            Context.Studios.Add(studio);
            Context.SaveChanges();

        }

        // Select * studios
        public List<Studio> GetStudios()
        {
            return Context.Studios.AsNoTracking().ToList();
        }

        public Studio GetStudioByID(int id)
        {
            var studio = Context.Studios.AsNoTracking().FirstOrDefault(m => m.ID == id);
            return studio;
        }

        // Update a studio

        public void UpdateStudio(int index, string title, int year, string location)
        {
            var studioToUpdate = Context.Studios.FirstOrDefault(m => m.ID == index);
            if (studioToUpdate != null)
            {
                studioToUpdate.Title = title;
                studioToUpdate.Year = year;
                studioToUpdate.Location = location;
                Context.SaveChanges();

            }
        }

        // Delete a studio

        public void DeleteStudio(int index)
        {
            var studioToDelete = Context.Studios.First(m => m.ID == index);
            if (studioToDelete != null)
            {
                Context.Studios.Remove(studioToDelete);
                Context.SaveChanges();
            }

        }

        // Delete a studio by title
        /*
        public void DeleteStudioByTitle(string title)
        {
            var studioToDelete = Context.Studios.First(m => m.Title == title);
            if (studioToDelete != null)
            {

                Context.Studios.Remove(studioToDelete);
                Context.SaveChanges();
            }
        }

        */
        #endregion

        public List<Studio> GetStudiosWithMovies()
        {
            return Context.Studios.Include(s => s.Movies).AsNoTracking().ToList();
        }


    }
}
