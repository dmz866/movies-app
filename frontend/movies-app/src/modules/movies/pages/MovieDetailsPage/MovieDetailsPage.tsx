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
    const { isLoading, movie, isFinished, getMovie } = useMovieDetailsPage();

    useEffect(() => {
        const id = search.get('movieId') ? +search.get('movieId')! : undefined;

        if (!id || isNaN(id)) navigateToMovies();

        getMovie(id!);
    }, [search, navigate, navigateToMovies, getMovie]);

    useEffect(() => {
        if (isFinished && !movie) {
            navigateToMovies();
        }
    }, [isFinished, movie]);

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
                            <img className='rounded-xl' alt={movie.name} src={movie.imageUrl || '/images/no-picture.jpg'} height={300} width={200} />
                        </div>
                        <div className="flex">
                            <div className="flex-row">
                                <p className="text-xl font-bold my-2">Actors</p>
                                {movie.actors?.map((a, indx) => <li key={`${a.name}-${indx}`}>{a.name}</li>)}
                            </div>
                        </div>
                        <div className="flex-row">
                            <p className="text-xl my-2">
                                <span className='font-bold mr-3'>Rating:</span>
                                <span>{movie.rating?.toFixed(2) || 0.0}</span>
                            </p>
                        </div>
                        <div className='flex justify-center mt-5'>
                            <button className="mx-auto w-96 border rounded-lg" onClick={navigateToMovies}>Back</button>
                        </div>
                    </div>
                }</div>
        </BasicContainer>
    );
};