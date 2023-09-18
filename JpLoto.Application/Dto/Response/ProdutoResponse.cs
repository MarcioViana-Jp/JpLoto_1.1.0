namespace JpLoto.Application.Dto.Response;

public class ProdutoResponse
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Name { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataCadastro { get; set; }
    public CategoriaResponse Categoria { get; set; }

    public ProdutoResponse(int id, string codigo, string name, string descricao, decimal preco, DateTime dataCadastro, CategoriaResponse categoria)
    {
        Id = id;
        Codigo = codigo;
        Name = name;
        Descricao = descricao;
        Preco = preco;
        DataCadastro = dataCadastro;
        Categoria = categoria;
    }
    /*
    public static ProdutoResponse ConverterParaResponse(Produto produto)
    {
        return new ProdutoResponse
        (
            produto.Id,
            produto.Codigo,
            produto.Name,
            produto.Descricao,
            produto.Preco,
            produto.DataCadastro,
            new CategoriaResponse(produto.Categoria.Id, produto.Categoria.Name)
        );
    } */
}