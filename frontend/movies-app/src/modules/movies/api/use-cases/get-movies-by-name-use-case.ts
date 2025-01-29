import { toast } from 'react-toastify';
import { getMoviesByName } from '../repositories';

export const getMoviesByNameUseCase = async (name: string) => {
    try {
        const { data: movie } = await getMoviesByName(name);

        return movie;
    }
    catch (e) {
        toast("An error occurred!. Try again");
        return [];
    }
};