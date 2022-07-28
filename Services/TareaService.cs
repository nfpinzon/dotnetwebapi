using webapi.Models;

namespace webapi.Services;

public class TareaService : ITareaService
{
    TareasContext context;

    public TareaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;

    }

    //public void Save(Tarea Tarea)
    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Tarea tarea)
    {
        var TareaActual = context.Tareas.Find(id);
        if(TareaActual != null){
            TareaActual.CategoriaId = tarea.CategoriaId;
            TareaActual.Titulo = tarea.Titulo;
            TareaActual.Descripcion = tarea.Descripcion;
            TareaActual.PrioridadTarea = tarea.PrioridadTarea;
            TareaActual.FechaCreacion = tarea.FechaCreacion;
            TareaActual.Resumen = tarea.Resumen;
            
            await context.SaveChangesAsync();
        }

    }
    public async Task Delete(Guid id)
    {
        var TareaActual = context.Tareas.Find(id);
        if(TareaActual != null){
            context.Remove(TareaActual);
            await context.SaveChangesAsync();
        }

    }
}
public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea Tarea);
    Task Update(Guid id, Tarea Tarea);
    Task Delete(Guid id);

}