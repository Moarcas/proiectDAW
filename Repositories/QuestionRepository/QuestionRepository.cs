using Data;
using Microsoft.EntityFrameworkCore;
using proiectDAW.Models;
using proiectDAW.Repositories.QuestionRepository;

public class QuestionRepository : IQuestionRepository {
    private readonly DataContext _context;

    public QuestionRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Question> GetById(Guid id) {
        var question = await _context.Questions.FirstOrDefaultAsync(q => q.id == id);

        if (question == null)
            throw new Exception("Question not found");

        return question;
    }

    public async Task<List<Question>> GetAll() {
        return await _context.Questions.ToListAsync();
    }

    public async Task<List<Question>> GetByUserId(Guid userId) {
        return await _context.Questions.Where(q => q.userId == userId).ToListAsync();
    }

    public async Task Add(Question question) {
        await _context.Questions.AddAsync(question);
    }

    public async Task Update(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) {
        var question = await GetById(id);
        _context.Questions.Remove(question);
    }

    public async Task<bool> SaveChanges() {
        return await _context.SaveChangesAsync() > 0;
    }
}