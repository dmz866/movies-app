import axios from "axios";
import { Movie } from "../../models";

const MOVIE_API_URL = `${process.env?.REACT_APP_MOVIE_API_URL}/movies`;

export const getMoviesByName = async (name: string) => {
    return axios.get<Movie[]>(`${MOVIE_API_URL}/search-by/${name}`);
}

export const getMovie = async (movieId: number) => {
    return axios.get<Movie>(`${MOVIE_API_URL}/${movieId}`);
}