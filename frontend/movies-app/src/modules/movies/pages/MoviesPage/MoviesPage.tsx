import { useContext, useEffect, useState } from 'react';
import { ClipLoader } from 'react-spinners';
import { BasicContainer } from '../../../common/components';
import { MovieCard } from '../../components';
import { MovieContext } from '../../context/movie-context';
import { useMoviesPage } from './useMoviesPage';

export const MoviesPage = () => {
    const { isLoading, handleSearch, noMovieFound, movies } = useMoviesPage();
    const { searchMovieName, updateSearchMovieName } = useContext(MovieContext);
    const [searchValue, setSearchValue] = useState('');
    const handleInput = (e: any) => {
        const fieldValue = e.nativeEvent.target.value;
        setSearchValue(fieldValue);
        updateSearchMovieName(fieldValue);
    }

    useEffect(() => {
        if (!searchMovieName) return;

        setSearchValue(searchMovieName);
    }, [searchMovieName])

    return (
        <BasicContainer>
            <div className="mx-32">
                <div className="justify-center flex-row p-4">
                    <p className="font-semibold text-white w-full">Search By Name:</p>
                    <div className='flex'>
                        <input defaultValue={searchValue} name='searchValue' type="text" className="text-black py-1 px-2 w-full border rounded-lg" onChange={handleInput} />
                        <button className="px-4 mx-2 border rounded-lg bg-white py-1" onClick={() => handleSearch(searchValue)}>Search</button>
                    </div>
                </div>
                <div className="flex justify-center">
                    {
                        isLoading &&
                        <ClipLoader
                            loading={isLoading}
                            size={150}
                            aria-label="Loading Spinner"
                            className='text-white'
                            data-testid="loader"
                        />
                    }
                </div>
                <div className="p-3 flex justify-center flex-wrap gap-8">
                    {noMovieFound && <p>No Movies found</p>}
                    {movies?.map((p, indx) => {
                        return <MovieCard key={`${p.name}-${indx}`} movie={p} />
                    })}
                </div>
            </div>
        </BasicContainer>
    );
};