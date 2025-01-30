import { useCallback, useEffect } from 'react';
import { useNavigate, useSearchParams } from "react-router";
import { ClipLoader } from 'react-spinners';
import { BasicContainer } from '../../../common/components';
import { MOVIES_PATH } from "../../constants";
import { useMovieDetailsPage } from './useMovieDetailsPage';

export const MovieDetailsPage = () => {
    const [search] = useSearchParams();
    const navigate = useNavigate();
    const navigateToMovies = useCallback(() => navigate(MOVIES_PATH), [navigate]);
    const { isLoading, movie, getMovie } = useMovieDetailsPage();

    useEffect(() => {
        const id = search.get('movieId') ? +search.get('movieId')! : undefined;

        if (!id || isNaN(id)) navigateToMovies();

        getMovie(id!);
    }, [search, navigate, navigateToMovies, getMovie]);

    return (
        <BasicContainer>
            <div className='flex mx-56 pb-10'>
                {
                    (isLoading || !movie) &&
                    <div className='flex justify-center'>
                        <ClipLoader loading={isLoading} size={150} aria-label="Loading Spinner" />
                    </div>
                }
                {
                    movie &&
                    <div className="text-white flex-row p-8 rounded-lg border border-gray-300 gap-4">
                        <p className="text-5xl font-bold mb-8">{movie.name}</p>
                        <div className='flex gap-x-4'>
                            <p className="text-sm font-bold my-4">{movie.description}</p>
                            <img className='rounded-xl' alt={movie.name} src={movie.imageUrl || '/images/no-picture.jpg'} height={300} width={200} /></div>

                        <div className="flex">
                            <div className="flex-row">
                                <p className="text-xl font-bold my-2">Actors</p>
                                {movie.actors?.map((a, indx) => <li key={`${a.name}-${indx}`}>{a.name}</li>)}
                            </div>
                            <div className="flex-row">
                                <p className="text-xl font-bold my-2">Rating: {movie.rating || 0.0}</p>
                            </div>
                        </div>
                        <div className='flex justify-center mt-5'>
                            <button className="mx-auto w-96 border rounded-lg" onClick={navigateToMovies}>Back</button>
                        </div>
                    </div>
                }</div>
        </BasicContainer>
    );
};