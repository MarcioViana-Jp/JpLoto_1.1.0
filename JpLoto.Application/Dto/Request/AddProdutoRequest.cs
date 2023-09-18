namespace JpLoto.Application.Dto.Request;

public class AddProdutoRequest
{
    public string Codigo { get; set; }
    public int IdCategoria { get; set; }
    public string Name { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public AddProdutoRequest(string codigo, int idCategoria, string name, string descricao, decimal preco)
    {
        Codigo = codigo;
        IdCategoria = idCategoria;
        Name = name;
        Descricao = descricao;
        Preco = preco;
    }
    /*
    public static Produto ConverterParaEntidade(InsercaoProdutoRequest produtoRequest)
    {
        return new Produto
        (
            produtoRequest.Codigo,
            produtoRequest.IdCategoria,
            produtoRequest.Name,
            produtoRequest.Descricao,
            produtoRequest.Preco
        );
    } */
}