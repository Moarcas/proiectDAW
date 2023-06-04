using Data;
using Microsoft.EntityFrameworkCore;
using proiectDAW.Models;
using proiectDAW.Repositories.AnswerRepository;

public class AnswerRepository : IAnswerRepository {
    private readonly DataContext _context;

    public AnswerRepository(DataContext context) {
        _context = context;
    }
    public async Task<Answer?> GetById(Guid id) {
        var answer = await _context.Answers.FirstOrDefaultAsync(a => a.id == id);   
        return answer;
    }

    public Task<List<Answer>> GetByQuestionId(Guid questionId) {
        return _context.Answers.Where(a => a.questionId == questionId).ToListAsync();
    }
    
    public async Task Add(Answer answer) {
        await _context.Answers.AddAsync(answer);
    }

    public async Task Delete(Guid id) {
        var answer = await GetById(id);
        _context.Answers.Remove(answer!);
    }

    public async Task Update(Answer answer) {
        _context.Answers.Update(answer);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> SaveChanges() {
        return await _context.SaveChangesAsync() > 0;
    }

}