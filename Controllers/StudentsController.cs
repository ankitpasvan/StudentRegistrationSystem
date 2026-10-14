using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Data;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Controllers;

public class StudentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Students — reads every student from SQL Server.
    public async Task<IActionResult> Index()
    {
        var students = await _context.Students
            .OrderBy(s => s.Id)
            .ToListAsync();
        return View(students);
    }

    // GET: /Students/Create — shows the empty registration form.
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Students/Create — validates and saves a new student.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        // 1. Server-side validation (Data Annotations on the Student model).
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        // 2. Friendly duplicate-email check before touching the database.
        if (await EmailExistsAsync(student.Email))
        {
            ModelState.AddModelError(nameof(Student.Email), "This email address is already registered.");
            return View(student);
        }

        // 3. Save. The unique index on Email is the final guard: if two requests
        //    with the same email arrive at the same moment, the database rejects
        //    the second one and we show a friendly message instead of crashing.
        try
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (IsUniqueViolation(ex))
        {
            ModelState.AddModelError(nameof(Student.Email), "This email address is already registered.");
            return View(student);
        }

        // 4. Post/Redirect/Get: redirect so a page refresh does not resubmit the form.
        TempData["SuccessMessage"] = $"Student {student.FullName} registered successfully.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Students/Edit/5 — shows the form filled with the student's data.
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // POST: /Students/Edit/5 — validates and saves the changes.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (id != student.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(student);
        }

        // Another student must not already use this email address.
        if (await _context.Students.AnyAsync(s => s.Id != id && s.Email.ToLower() == student.Email.ToLower()))
        {
            ModelState.AddModelError(nameof(Student.Email), "This email address is already registered.");
            return View(student);
        }

        try
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (IsUniqueViolation(ex))
        {
            ModelState.AddModelError(nameof(Student.Email), "This email address is already registered.");
            return View(student);
        }

        TempData["SuccessMessage"] = $"Student {student.FullName} updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Students/Delete/5 — asks "are you sure?" before deleting.
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // POST: /Students/Delete/5 — performs the deletion.
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = $"Student {student.FullName} deleted successfully.";
        return RedirectToAction(nameof(Index));
    }

    // Case-insensitive email check (SQL Server's default collation is case-insensitive,
    // so the database treats "A@x.com" and "a@x.com" as the same address).
    private Task<bool> EmailExistsAsync(string email) =>
        _context.Students.AnyAsync(s => s.Email.ToLower() == email.ToLower());

    // SQL Server error 2601 / 2627 = unique index / unique constraint violation.
    private static bool IsUniqueViolation(DbUpdateException ex) =>
        ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627);
}
