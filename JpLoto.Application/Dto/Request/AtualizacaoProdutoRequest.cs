namespace JpLoto.Application.Dto.Request;

public class AtualizacaoProdutoRequest
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public int IdCategoria { get; set; }
    public string Name { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public AtualizacaoProdutoRequest(string codigo, int idCategoria, string name, string descricao, decimal preco)
    {
        Codigo = codigo;
        IdCategoria = idCategoria;
        Name = name;
        Descricao = descricao;
        Preco = preco;
    }
    /*
    public static Produto ConverterParaEntidade(AtualizacaoProdutoRequest produtoRequest)
    {
        return new Produto
        (
            produtoRequest.Id,
            produtoRequest.Codigo,
            produtoRequest.IdCategoria,
            produtoRequest.Name,
            produtoRequest.Descricao,
            produtoRequest.Preco
        );
    } */
}