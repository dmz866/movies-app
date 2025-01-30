import { useCallback, useMemo, useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router';
import { Header } from '../../common/components';
import { ACTORS_PATH, MOVIE_PATH, MOVIES_PATH } from '../constants';
import { IMovieContext, MovieContext } from '../context/movie-context';
import { Movie } from '../models';
import { ActorsPage } from '../pages/ActorsPage/ActorsPage';
import { HomePage } from '../pages/HomePage/HomePage';
import { MoviePage } from '../pages/MoviePage/MoviePage';
import { MoviesPage } from '../pages/MoviesPage/MoviesPage';

const headerLinks = [
    {
        name: 'Movies',
        path: MOVIES_PATH
    },
    {
        name: 'Actors',
        path: ACTORS_PATH
    }
];

export const MoviesNavigationRouter = () => {
    const [searchMovieName, setSearchMovieName] = useState<string | undefined>();
    const [moviesFound, setMoviesFound] = useState<Movie[]>();
    const updateSearchMovieName = useCallback((value: string) => {
        setSearchMovieName(value);
    }, []);
    const updateMoviesFound = useCallback((value: Movie[]) => {
        setMoviesFound(value);
    }, []);
    const contextValue = useMemo(() => ({
        searchMovieName,
        moviesFound,
        updateSearchMovieName,
        updateMoviesFound,
    } as IMovieContext), [searchMovieName, moviesFound, updateSearchMovieName, updateMoviesFound]);

    return (
        <div className="bg-movies h-full">
            <MovieContext.Provider value={contextValue}>
                <BrowserRouter>
                    <Header links={headerLinks} />
                    <Routes>
                        <Route path='/' element={<HomePage />} />
                        <Route path={MOVIES_PATH} element={<MoviesPage />} />
                        <Route path={ACTORS_PATH} element={<ActorsPage />} />
                        <Route path={MOVIE_PATH} element={<MoviePage />} />
                    </Routes>
                </BrowserRouter>
            </MovieContext.Provider>
        </div>
    );
}
