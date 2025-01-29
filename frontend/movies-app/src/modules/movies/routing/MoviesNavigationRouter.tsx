import { BrowserRouter, Route, Routes } from 'react-router';
import { ACTORS_PATH, MOVIE_PATH, MOVIES_PATH } from '../constants';
import { ActorsPage } from '../pages/ActorsPage/ActorsPage';
import { HomePage } from '../pages/HomePage/HomePage';
import { MoviePage } from '../pages/MoviePage/MoviePage';
import { MoviesPage } from '../pages/MoviesPage/MoviesPage';

export const MoviesNavigationRouter = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<HomePage />} />
                <Route path={MOVIES_PATH} element={<MoviesPage />} />
                <Route path={ACTORS_PATH} element={<ActorsPage />} />
                <Route path={MOVIE_PATH} element={<MoviePage />} />
            </Routes>
        </BrowserRouter>
    );
}
