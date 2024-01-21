using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using youtube_notes_api.Data;
using youtube_notes_api.Entities;

namespace youtube_notes_api.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]s")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public NoteController(DataContext _dataContext)
        {
            this._dataContext = _dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAllNotes()
        {
            Console.WriteLine("Getting all notes.");
            Dictionary<string, List<Note>> json = new Dictionary<string, List<Note>>();
            return Ok(_dataContext.Notes.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Note> GetNoteById(int id)
        {
            Console.WriteLine("Get notes by id");
            try
            {
                Note note = _dataContext.Notes.Find(id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Note> CreateNote([FromBody] Note note)
        {
            Console.WriteLine($"Creating notes for {note}");
            Console.WriteLine(note);
            try
            {
                _dataContext.Notes.Add(note);
                _dataContext.SaveChanges();

                return note;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Note> EditNote(int id, [FromBody] Note newNote)
        {
            Console.WriteLine($"Updating notes for {newNote}");
            try
            {

                var dbNote = _dataContext.Notes.Find(id);
                if (dbNote is null)
                {
                    throw new Exception($"Note {id} not  found");
                }
                dbNote.Title = newNote.Title;
                dbNote.Description = newNote.Description;
                dbNote.Content = newNote.Content;
                dbNote.Url = newNote.Url;
                _dataContext.SaveChanges();
                return Ok(_dataContext.Notes.Find(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteNote(int id)
        {
            Console.WriteLine($"Deleting note with id: {id}");
            try
            {
                var dbNote = _dataContext.Notes.Find(id);
                if (dbNote is null)
                {
                    throw new Exception($"Note {id} not  found");
                }
                _dataContext.Notes.Remove(dbNote);
                _dataContext.SaveChanges();
                return Ok("Delete successful");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
