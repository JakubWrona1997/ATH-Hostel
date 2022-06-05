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
using ATH_Hostel.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace ATH_Hostel.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHostelRepository _hostelRepository;

        public RoomsController(IRoomRepository roomRepository, IHostelRepository hostelRepository)
        {
            _roomRepository = roomRepository;
            _hostelRepository = hostelRepository;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var roomlItemViewModel = await _roomRepository.GetAllRooms();

            return View(roomlItemViewModel);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomViewModel = await _roomRepository.GetRoomById((int)id);

            if (roomViewModel == null)
            {
                return NotFound();
            }

            return View(roomViewModel);
        }

        // GET: Rooms/Create
        [Authorize(Roles = "Admin, Staff")]
        public IActionResult Create()
        {
            ViewData["HostelId"] = new SelectList(_hostelRepository.GetAllHostels().Result, "Id", "Name");
            ViewData["RoomType"] = new SelectList(Enum.GetValues(typeof(RoomType)));
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,HostelId,PriceForNight,BedsAmount,RoomType")] CreateRoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
                await _roomRepository.CreateRoom(roomViewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["HostelId"] = new SelectList(_hostelRepository.GetAllHostels().Result, "Id", "Name");
            ViewData["RoomType"] = new SelectList(Enum.GetValues(typeof(RoomType)));
            return View(roomViewModel);
        }

        // GET: Rooms/Edit/5
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var editRoom = await _roomRepository.GetRoomToEdit((int)id);

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
        [Authorize(Roles = "Admin, Staff")]
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
                    await _roomRepository.EditRoom(editRoomViewModel, id);
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
            //ViewData["HostelId"] = new SelectList(_context.Hostels, "Id", "Id", editRoomViewModel.Id);
            ViewData["RoomType"] = new SelectList(Enum.GetValues(typeof(RoomType)));
            return View(editRoomViewModel);
        }

        // GET: Rooms/Delete/5
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _roomRepository.GetRoomById((int)id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _roomRepository.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _roomRepository.GetAllRooms().Result.Any(e => e.Id == id);
        }
    }
}
