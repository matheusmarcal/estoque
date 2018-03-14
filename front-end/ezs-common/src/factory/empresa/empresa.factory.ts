import { BaseFactory } from './../base.factory';
import { EmpresaModel } from './../../model/server/empresa.model';

export class Factory extends BaseFactory {

    private title = 'empresa';

    public add = async (model: EmpresaModel) => {
        try {
            let result = await this.put('/api/empresa/add', model) as EmpresaModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public update = async (model: EmpresaModel) => {
        try {
            let result = await this.post('/api/empresa/update', model) as EmpresaModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public disable = async (id: number | string) => {
        try {
            let result = await this.delete('/api/empresa/disable', { params: { id: id } });
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public detail = async (id: number | string) => {
        try {
            let result = await this.get(`/api/empresa/${id}`) as EmpresaModel;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

    public all = async () => {
        try {
            let result = await this.get('/api/empresa') as Array < EmpresaModel > ;
            return result;
        }
        catch (error) {
            throw error;
        }
    }

}