using CannaWatch.Commands;
using CannaWatch.Data;
using CannaWatch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CannaWatch.ViewModels
{
    public class AddPlantViewModel
    {
        private AppDbContext _context;

        public ObservableCollection<Strain> Strains { get; set; }

        public AddPlantViewModel()
        {
            _context = new AppDbContext();
            
            LoadStrains();
        }

        public void LoadStrains()
        {
            Strains = new ObservableCollection<Strain>(_context.Strains.ToList());

        }
    }
}
