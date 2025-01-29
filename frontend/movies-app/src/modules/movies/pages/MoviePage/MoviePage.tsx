import { useCallback, useEffect } from 'react';
import { useNavigate, useSearchParams } from "react-router";
import { ClipLoader } from 'react-spinners';
import { BasicContainer } from '../../../common/component';
import { MOVIES_PATH } from "../../constants";
import { useMoviePage } from './useMoviePage';

export const MoviePage = () => {
    const [search] = useSearchParams();
    const navigate = useNavigate();
    const navigateToMovies = useCallback(() => navigate(MOVIES_PATH), []);
    const { isLoading, movie, getMovie } = useMoviePage();

    useEffect(() => {
        const id = search.get('movieId') ? +search.get('movieId')! : undefined;

        if (!id || isNaN(id)) navigateToMovies();

        getMovie(id!);
    }, [search]);

    return (
        <BasicContainer>
            <div className='flex mx-56'>
                {
                    (isLoading || !movie) &&
                    <div className='flex justify-center'>
                        <ClipLoader loading={isLoading} size={150} aria-label="Loading Spinner" />
                    </div>
                }
                {
                    movie &&
                    <div className="flex-row p-8 rounded-lg border border-gray-300 gap-4">
                        <p className="text-5xl font-bold mb-8">{movie.name}</p>
                        <div className='flex gap-x-4'>
                            <p className="text-sm font-bold my-4">{movie.description}</p>
                            <img className='rounded-xl' alt={movie.name} src={movie.imageUrl || '/images/no-picture.jpg'} height={300} width={200} /></div>
                        <p className="text-xl font-bold my-2">Actors</p>
                        <div className="flex">
                            {movie.actors?.map((a, indx) => <span key={`${a.name}-${indx}`}>{a.name}</span>)}
                        </div>
                        <div className='flex justify-center mt-5'>
                            <button className="mx-auto w-96 border rounded-lg" onClick={navigateToMovies}>Back</button>
                        </div>
                    </div>
                }</div>
        </BasicContainer>
    );
};