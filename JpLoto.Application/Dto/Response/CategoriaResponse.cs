namespace JpLoto.Application.Dto.Response;

public class CategoriaResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CategoriaResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
    /*
    public static CategoriaResponse ConverterParaResponse(Categoria categoria)
    {
        return new CategoriaResponse
        (
            categoria.Id,
            categoria.Name
        );
    } */
}