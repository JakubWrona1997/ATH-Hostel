using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATH_Hostel.Infrastructure;
using ATH_Hostel.Infrastructure.Models;
using ATH_Hostel.Infrastructure.Enums;
using AutoMapper;
using ATH_Hostel.ViewModels;
using ATH_Hostel.ViewModels.Room;

namespace ATH_Hostel.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HostelDBContext _context;
        private readonly IMapper _mapper;

        public RoomsController(HostelDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var hostelDBContext = await _context.Rooms.Include(r => r.Hostel).ToListAsync();
            var roomlItemViewModel = _mapper.Map<List<RoomItemViewModel>>(hostelDBContext);

            return View(roomlItemViewModel);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Hostel)
                .FirstOrDefaultAsync(m => m.Id == id);

            var roomlViewModel = _mapper.Map<RoomViewModel>(room);
            if (roomlViewModel == null)
            {
                return NotFound();
            }

            return View(roomlViewModel);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["HostelId"] = new SelectList(_context.Hostels, "Id", "Id");
            ViewData["RoomType"] = new SelectList(Enum.GetValues(typeof(RoomType)));
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,HostelId,PriceForNight,BedsAmount,RoomType")] CreateRoomViewModel roomViewModel)
        {            
            if (ModelState.IsValid)
            {
                var room = _mapper.Map<Room>(roomViewModel);
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HostelId"] = new SelectList(_context.Hostels, "Id", "Id", roomViewModel.HostelId);
            ViewData["RoomType"] = new SelectList(Enum.GetValues(typeof(RoomType)));
            return View(roomViewModel);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var room = await _context.Rooms.FindAsync(id);
            var editRoom = _mapper.Map<EditRoomViewModel>(room);

            if (editRoom == null)
            {
                return NotFound();
            }
            //ViewData["HostelId"] = new SelectList(_context.Hostels, "Id", "Id", room.HostelId);
            ViewData["RoomType"] = new SelectList(Enum.GetValues(typeof(RoomType)));
            return View(editRoom);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PriceForNight,BedsAmount,RoomType")] EditRoomViewModel editRoomViewModel)
        {
            if (id != editRoomViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var roomEdit = _mapper.Map<Room>(editRoomViewModel);
                    _context.Update(roomEdit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(editRoomViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["HostelId"] = new SelectList(_context.Hostels, "Id", "Id", editRoomViewModel.HostelId);
            ViewData["RoomType"] = new SelectList(Enum.GetValues(typeof(RoomType)));
            return View(editRoomViewModel);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Hostel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
