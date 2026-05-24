CREATE TABLE bautismo (
    id SERIAL PRIMARY KEY,

    sacramento VARCHAR(200) NOT NULL DEFAULT '1',

    bautizando_id INT NOT NULL,
    padre_id INT NOT NULL,
    madre_id INT NOT NULL,

    tipo_union_padres VARCHAR(50) NOT NULL,
    fecha_matrimonio_padres DATE NOT NULL,

    abuelo_materno_id INT NOT NULL,
    abuela_materna_id INT NOT NULL,

    abuelo_paterno_id INT NOT NULL,
    abuela_paterna_id INT NOT NULL,

    padrino_id INT NOT NULL,
    madrina_id INT NOT NULL,

    declarante_id INT NOT NULL,

    CONSTRAINT fk_bautismo_bautizando
        FOREIGN KEY (bautizando_id)
        REFERENCES persona(id),

    CONSTRAINT fk_bautismo_padre
        FOREIGN KEY (padre_id)
        REFERENCES persona(id),

    CONSTRAINT fk_bautismo_madre
        FOREIGN KEY (madre_id)
        REFERENCES persona(id),

    CONSTRAINT fk_bautismo_abuelo_materno
        FOREIGN KEY (abuelo_materno_id)
        REFERENCES persona(id),

    CONSTRAINT fk_bautismo_abuela_materna
        FOREIGN KEY (abuela_materna_id)
        REFERENCES persona(id),

    CONSTRAINT fk_bautismo_abuelo_paterno
        FOREIGN KEY (abuelo_paterno_id)
        REFERENCES persona(id),

    CONSTRAINT fk_bautismo_abuela_paterna
        FOREIGN KEY (abuela_paterna_id)
        REFERENCES persona(id),

    CONSTRAINT fk_bautismo_padrino
        FOREIGN KEY (padrino_id)
        REFERENCES persona(id),

    CONSTRAINT fk_bautismo_madrina
        FOREIGN KEY (madrina_id)
        REFERENCES persona(id),

    CONSTRAINT fk_bautismo_declarante
        FOREIGN KEY (declarante_id)
        REFERENCES persona(id)
);