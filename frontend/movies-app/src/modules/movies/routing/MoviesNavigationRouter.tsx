import { useCallback, useMemo, useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router';
import { ACTORS_PATH, MOVIE_PATH, MOVIES_PATH } from '../constants';
import { IMovieContext, MovieContext } from '../context/movie-context';
import { ActorsPage } from '../pages/ActorsPage/ActorsPage';
import { HomePage } from '../pages/HomePage/HomePage';
import { MoviePage } from '../pages/MoviePage/MoviePage';
import { MoviesPage } from '../pages/MoviesPage/MoviesPage';

export const MoviesNavigationRouter = () => {
    const [searchMovieName, setSearchMovieName] = useState<string | undefined>();
    const updateSearchMovieName = useCallback((value: string) => {
        setSearchMovieName(value);
    }, []);
    const contextValue = useMemo(() => ({
        searchMovieName,
        updateSearchMovieName
    } as IMovieContext), [searchMovieName, updateSearchMovieName]);

    return (
        <MovieContext.Provider value={contextValue}>
            <BrowserRouter>
                <Routes>
                    <Route path='/' element={<HomePage />} />
                    <Route path={MOVIES_PATH} element={<MoviesPage />} />
                    <Route path={ACTORS_PATH} element={<ActorsPage />} />
                    <Route path={MOVIE_PATH} element={<MoviePage />} />
                </Routes>
            </BrowserRouter>
        </MovieContext.Provider>

    );
}
