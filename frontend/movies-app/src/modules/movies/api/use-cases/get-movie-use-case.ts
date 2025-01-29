import { toast } from 'react-toastify';
import { getMovie } from '../repositories';

export const getMovieUseCase = async (movieId: number) => {
    try {
        const { data: movie } = await getMovie(movieId);

        return movie;
    }
    catch (e) {
        toast("An error occurred!. Try again");
        return undefined;
    }
};