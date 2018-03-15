import { BaseFactory } from './../base.factory';
import { ProdutoModel } from './../../model/server/produto.model';

export class Factory extends BaseFactory {

    private title = 'produto';

    public add = async (model: ProdutoModel) => {
        try {
            let result = await this.put('/api/produto/add', model) as ProdutoModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public update = async (model: ProdutoModel) => {
        try {
            let result = await this.post('/api/produto/update', model) as ProdutoModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public disable = async (id: number | string) => {
        try {
            let result = await this.delete('/api/produto/disable', { params: { id: id } });
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public detail = async (id: number | string) => {
        try {
            let result = await this.get(`/api/produto/${id}`) as ProdutoModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public all = async () => {
        try {
            let result = await this.get('/api/produto') as Array < ProdutoModel > ;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public allByTermo = async (termo:string) => {
        try {
            let result = await this.get('/api/produto/termo',{
                params:{
                    termo:termo
                }
            }) as Array < ProdutoModel > ;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

}