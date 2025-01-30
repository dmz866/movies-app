import { toast } from 'react-toastify';
import { getActor } from '../repositories';

export const getActorUseCase = async (actorId: number) => {
    try {
        const { data: actor } = await getActor(actorId);

        return actor;
    }
    catch (e) {
        toast("An error occurred!. Try again");
        return undefined;
    }
};