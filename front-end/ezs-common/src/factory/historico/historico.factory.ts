import { BaseFactory } from './../base.factory';
import { HistoricoModel } from './../../model/server/historico.model';

export class Factory extends BaseFactory {

    private title = 'historico';

    public add = async (model: HistoricoModel) => {
        try {
            let result = await this.put('/api/historico/add', model) as HistoricoModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public update = async (model: HistoricoModel) => {
        try {
            let result = await this.post('/api/historico/update', model) as HistoricoModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public disable = async (id: number | string) => {
        try {
            let result = await this.delete('/api/historico/disable', { params: { id: id } });
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public detail = async (id: number | string) => {
        try {
            let result = await this.get(`/api/historico/${id}`) as HistoricoModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public all = async () => {
        try {
            let result = await this.get('/api/historico') as Array < HistoricoModel > ;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

}