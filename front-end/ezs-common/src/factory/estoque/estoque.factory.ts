import { BaseFactory } from './../base.factory';
import { EstoqueModel } from './../../model/server/estoque.model';
import { EstoqueGeralModel } from '../../model/server/estoque-geral.model';

export class Factory extends BaseFactory {

    private title = 'estoque';

    public add = async (model: EstoqueModel) => {
        try {
            let result = await this.put('/api/estoque/add', model) as EstoqueModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public update = async (model: EstoqueModel) => {
        try {
            let result = await this.post('/api/estoque/update', model) as EstoqueModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public disable = async (id: number | string) => {
        try {
            let result = await this.delete('/api/estoque/disable', { params: { id: id } });
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public detail = async (id: number | string) => {
        try {
            let result = await this.get(`/api/estoque/${id}`) as EstoqueModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public all = async () => {
        try {
            let result = await this.get('/api/estoque') as Array < EstoqueModel > ;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public allGeral = async () => {
        try {
            let result = await this.get('/api/estoque/business/geral') as Array < EstoqueGeralModel > ;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

}