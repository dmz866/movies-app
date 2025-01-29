import { toast } from 'react-toastify';
import { getActorsByName } from '../repositories';

export const getActorsByNameUseCase = async (name: string) => {
    try {
        const { data: actor } = await getActorsByName(name);

        return actor;
    }
    catch (e) {
        toast("An error occurred!. Try again");
        return [];
    }
};