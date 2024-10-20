"use client";

import Button from "antd/es/button/button";
import { Singlets } from "../components/Singlets";
import { useEffect, useState } from "react";
import { SingletRequest, createSinglet, deleteSinglet, getAllSinglets, updateSinglet } from "../services/singlets";
import Title from "antd/es/skeleton/Title";
import { CreateUpdateSinglets, Mode } from "../components/CreateUpdateSinglet";

export default function SingletPage(){
const defaultValues = {
    title: "",
    description: "",
    price: 1,
} as Singlet
const [values, setValues] = useState<Singlet>(defaultValues);

const [singlets, setSinglets] = useState<Singlet[]>([]);
const [loading, setLoading] = useState(true);
const [isModalOpen, setIsModalOpen] = useState(false);
const [mode, setMode] = useState(Mode.Create);

useEffect(() => {
    const getSinglets = async() =>{
      const singlets = await getAllSinglets();
      setLoading(false);
      setSinglets(singlets);
    };
    getSinglets();
 },[])

const handleCreateSinglet = async (request: SingletRequest) => {
    await createSinglet(request);
    closeModal();

    const singlets = await getAllSinglets();
    setSinglets(singlets);
}

const handleUpdateSinglet = async(id:string, request: SingletRequest) => {
    await updateSinglet(id, request);
    closeModal();

    const singlets = await getAllSinglets();
    setSinglets(singlets);
};

const handleDeleteSinglet = async (id: string) => {
    await deleteSinglet(id);
    closeModal();

    const singlets = await getAllSinglets();
    setSinglets(singlets);
};

const openModal = () => {
    setIsModalOpen(true);
};

const closeModal = () => {
    setValues(defaultValues);
    setIsModalOpen(false);
};

const openEditModal = (singlet: Singlet) => {
  setMode(Mode.Edit);
  setValues(singlet);
  setIsModalOpen(true);
};

    return(
        <div>
            <Button type="primary" onClick={openModal}>Добавить книгу</Button>
            
             <CreateUpdateSinglets
                  mode={mode}
                  values={values}
                  isModalOpen={isModalOpen}
                  handleCreate={handleCreateSinglet}
                  handleUpdate={handleUpdateSinglet}
                  handleCancel={closeModal}
              />

            {loading ? <Title>Loading...</Title> : <Singlets singlets={singlets} handleOpen={openEditModal} handleDelete={handleDeleteSinglet}/>}
        </div>
    )
}